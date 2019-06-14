using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class SQLMerchantRepository : IMerchantRepository
    {
        private AppDbContext context;

        public SQLMerchantRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Merchant AddMerchantDetails(Merchant merchant)
        {
            context.Merchant.Add(merchant);
            context.SaveChanges();
            return merchant;
        }

        public List<Merchant> GetAllMerchants()
        {
            return context.Merchant.ToList();
        }
    }
}
