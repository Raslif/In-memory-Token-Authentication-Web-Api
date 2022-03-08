using CutomTokenAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CutomTokenAuth
{
    public class TokenManager : ITokenManager
    {
        private static List<Token> listOfTokens;

        public TokenManager()
        {
            listOfTokens = listOfTokens ?? new List<Token>();
        }

        public async Task<bool> Authenticate(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return false;
            // Check the database for the validity of user

            return await Task.FromResult(userName.Trim() == "admin" && password.Trim() == "pass");
        }

        public async Task<Token> CreateToken()
        {
            var token = new Token()
            {
                Value = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddMinutes(1)
            };

            listOfTokens.Add(token);

            return await Task.FromResult(token);
        }

        public async Task<bool> VerifyToken(string token)
        {
            var result = listOfTokens.Any(item => item.Value == token && item.ExpiryDate > DateTime.Now);

            return await Task.FromResult(result);
        }
    }
}