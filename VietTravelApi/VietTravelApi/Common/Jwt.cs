using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VietTravelApi.Models;

namespace VietTravelApi.Common
{
    public class Jwt
    {
        private readonly IConfiguration _configuration;
        private readonly HeaderJwt headerJwt;
        private readonly string secretKeyJwt;
        public Jwt(IConfiguration configuration)
        {
            _configuration = configuration;
            headerJwt = new HeaderJwt();
            headerJwt.Typ = "JWT";
            headerJwt.Alg = "HS256";
            secretKeyJwt = _configuration["ClientSecret"];
        }

        public string CreateToken(JwtData dataJwt) {
            string header = EncodeBase64(JsonConvert.SerializeObject(headerJwt));
            string payload = EncodeBase64(JsonConvert.SerializeObject(dataJwt));
            string signature = HMACSHA256Alg(header, payload, secretKeyJwt);
            return header + "." + payload + "." + signature;
        }
        public JwtData ConfirmRoleUserToken(string token)
        {
            string[] jwtIngredient = token.Split(".");
            string payload = jwtIngredient[1];

            JwtData data = (JsonConvert.DeserializeObject<JwtData>(DecodeBase64(payload)));
            return data;

        }
        public bool ConfirmToken(string token)
        {
            string[] jwtIngredient = token.Split(".");
            string header = jwtIngredient[0];
            string payload = jwtIngredient[1];
            string signature = jwtIngredient[2];
            string signatureConfirm = HMACSHA256Alg(header, payload, secretKeyJwt);
            if (signature.Equals(signatureConfirm)) return true;
            return false;
        }
        public bool Auth(string roleUser, string token)
        {
            string[] tokens = token.Split(" ");
            token = tokens[1];
            JwtData data = ConfirmRoleUserToken(token);
            if (data.Role.Equals(roleUser) && ConfirmToken(token)==true) return true;
            return false;
        }
        public string EncodeBase64(string data)
        {
            byte[] bytesToEncode = Encoding.UTF8.GetBytes(data);
            string base64String = Convert.ToBase64String(bytesToEncode);
            return base64String;
        }
        public string DecodeBase64(string data)
        {
            byte[] bytesToDecode = Convert.FromBase64String(data);
            string decodedString = Encoding.UTF8.GetString(bytesToDecode);
            return decodedString;
        }
        public string HMACSHA256Alg(string header, string payload, string secretKey)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(secretKeyJwt);
            byte[] jwtBytes = Encoding.UTF8.GetBytes(header + "." + payload);
            var hmac = new HMACSHA256(keyBytes);
            byte[] signatureBytes = hmac.ComputeHash(jwtBytes);
            string signature = Convert.ToBase64String(signatureBytes);
            return signature;
        }

    }
}
