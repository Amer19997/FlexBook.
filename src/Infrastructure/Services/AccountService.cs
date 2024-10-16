﻿using System.Security.Cryptography;
using System.Text;
using FlexBook.Application.Common.Interfaces;

namespace FlexBook.Infrastructure.Services;
public class AccountService : IAccountService
{
    public async Task<string> GetHashString(string inputString)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
