using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.HETHONG.TAIKHOAN.Dtos;

namespace Model.COMMON
{
    public class Encrypt_Decrypt
    {
        private static string key { get; set; } = "utc2cqcnttk62nph6251071033g4c4c5lo080nhldc0";

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new System.Security.Cryptography.RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string EncodePassword(string pass, string salt)
        {
            var bytes = Encoding.Unicode.GetBytes(pass);
            var src = Convert.FromBase64String(salt);
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(pass + salt));
            return Convert.ToBase64String(data);
        }

        public static string GenerateJwtToken(MODELTaiKhoan taikhoan, IConfiguration config)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, taikhoan.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, taikhoan.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(Model.COMMON.CommonConst.ExpireTime),
                signingCredentials: credentials);

            return tokenHandler.WriteToken(token);
        }

    }
}
