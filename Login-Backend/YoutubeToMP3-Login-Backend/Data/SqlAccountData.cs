using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeToMP3_Login_Backend.Models;

namespace YoutubeToMP3_Login_Backend.Data
{
    public class SqlAccountData : IAccountData
    {

        private DBContext _dbContext;

        public SqlAccountData(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = _dbContext.Accounts.ToList();

            return accounts;

        }
        public Account GetAccount(int id)
        {
            Account account = _dbContext.Accounts.SingleOrDefault(x => x.AccountId == id);
            
            return account;
        }

        public Account AddAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            return account;
        }
        public Account UpdateAccount(Account existingAccount)
        {
            _dbContext.Accounts.Update(existingAccount);
            _dbContext.SaveChanges();
            
            return existingAccount;
        }

        public void DeleteAccount(Account account)
        {
            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
        }
    }
}
