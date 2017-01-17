using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoAuction.DAL.EFContext;
using AutoAuction.DAL.Repositories;
using AutoAuction.DAL.Interfaces;
using Quartz;

namespace AutoAuction.Jobs
{
    public class AuctionChecker:IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            EFUnitOfWork dataBase = new EFUnitOfWork(new AuctionContext("name=DefaultConnection"));          
            var acLots = dataBase.Lots.GetAll().ToList();
            for (int i = 0; i < acLots.Count; i++)
            {
                if (acLots[i].EndLotSaleDate <= DateTime.Today)
                {
                    var listLotACL =
                        dataBase.CustomerLots.GetAll().Where(l => l.Lot.LotId == acLots[i].LotId).ToList();
                    for (int j = 0; j < listLotACL.Count; j++)
                    {
                        if (acLots[i].CurrentPrice == listLotACL[j].CustomerBet)
                        {
                            listLotACL[j].Lot.IsSold = true;
                            listLotACL[j].WinAuction = true;
                            dataBase.CustomerLots.Update(listLotACL[j]);
                        }

                    }
                    if ((acLots[i].StartLotPrice == acLots[i].CurrentPrice) && (acLots[i].IsSold == false))
                    {
                        acLots[i].IsSold = true;
                        dataBase.Lots.Update(acLots[i]);
                    }
                    dataBase.Save();
                }
            }
        }
    }
}