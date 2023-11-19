using CA_Barbut.Models;
using CA_Barbut.Repository;
using CA_Barbut.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Barbut.Concrete
{
    public class BalanceRepository : IBalanceRepository
    {
        BarbutGameDbContext context = new BarbutGameDbContext();
        public int GetById(int id)
        {
            return context.Balances.FirstOrDefault(x => x.Id == id).Point;
        }

        public void PointAdd(Balance balance)
        {
            var result = context.Balances.FirstOrDefault(x => x.Id == balance.Id);
            result.Point += balance.Point;
            if (context.SaveChanges() > 0)
            {
                Messages.PointAddSuccess();
            }
            else
            {
                Messages.PointAddError();
            }
        }

        public void PointRemove(Balance balance)
        {
            var result = context.Balances.Find(balance.Id);
            result.Point -= balance.Point;
            if (context.SaveChanges() > 0)
            {
                Messages.PointRemoveSuccess();
            }
            else
            {
                Messages.PointRemoveError();
            }
        }
    }
}
