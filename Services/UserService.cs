using AdoNetTask.Helpers;
using AdoNetTask.Models;
using System.Security.Cryptography;
using System.Text;

namespace AdoNetTask.Services
{
    public class UserSerice : IBaseService<User>
    {
        public int Register(User data)
        {
            using SHA256 sha256Hash = SHA256.Create();
            string passwordHash = HashPasword(sha256Hash, data.Password);
            string query = $"INSERT INTO Users VALUES (N'{data.Name}', N'{data.Surname}', {data.Password})";
            return SqlHelper.Exec(query);
        }
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(User data)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, User data)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
