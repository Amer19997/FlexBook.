using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Helpers;

namespace FlexBook.Application.Common.Interfaces
{
    public interface ICacheService 
    {
        void AddAsync<T> (string prefix, string key, double? expirationTimeInMinutes, T value) where T : class; 
        T GetAsync<T> (string prefix, string key,CancellationToken cancellationToken) where T : class;
        void Delete(string prefix, string key);
        //T TryToGet<T> (string prefix, string key,out bool isExist) where T : class;
        //Task RefreshAsync (string prefix, string key);
        // Task DeleteAsync(string prefix, string key);


    }
}
