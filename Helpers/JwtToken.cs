using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CRUD_PatientLabTestAPI.Helpers
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken() 
        {
            //Also note that security key length must be >256b
            //so yu have to make sure that your private key has a proper length
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                (SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            //Finally cretae a token
            var header = new JwtHeader(credentials);

            //Token will be good for 1 minutes
            DateTime Expiry = DateTime.UtcNow.AddMinutes(60);
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            //Some Payload that contain information about the patient
            var payload = new JwtPayload
            {
                {"sub", "testSubject" },
                {"Name", "Admin" },
                {"Email", "admin@gmail.com" },
                {"exp", ts },
                {"iss", "http://localhost:5221" },
                {"aud", "http://localhost:5221" }
            };

            var secToken = new JwtSecurityToken ( header, payload );
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken); //security Token

            Console.WriteLine(tokenString);
            Console.WriteLine("Consume Token");

            return tokenString;

        }
    }
}
