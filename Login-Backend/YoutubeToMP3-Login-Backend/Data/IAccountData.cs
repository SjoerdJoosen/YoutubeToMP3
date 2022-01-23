using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeToMP3_Login_Backend.Models;

namespace YoutubeToMP3_Login_Backend.Data
{
    public interface IAccountData
    {
        List<Account> GetAccounts();

        Account GetAccount(int Id);

        Account AddAccount(Account account);

        void DeleteAccount(Account account);

        Account UpdateAccount(Account existingAccount);
    }
}
