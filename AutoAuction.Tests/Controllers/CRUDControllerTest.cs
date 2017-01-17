using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using AutoAuction.Controllers;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;
using AutoAuction.DAL.Repositories;
using AutoAuction.Models;
using AutoAuction.Providers;
using AutoAuction.Util;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutoAuction.Tests.Controllers
{
    [TestClass]
    public class CRUDControllerTest
    {
        private List<Lot> ListLot;
        private Mock<IUnitofWork> _moqDataBase;
        CRUDController controller;
        CustomerRoleProvider provider;
        [TestInitialize]
        public void Initialize()
        {
            _moqDataBase = new Mock<IUnitofWork>();
            controller = new CRUDController(_moqDataBase.Object);
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            provider=new CustomerRoleProvider();
            ListLot = new List<Lot>
            {
                new Lot
                {
                    LotId = 1,
                    LotName = "Audi",
                    LotImageUrl = "",
                    StarLotSaleDate = DateTime.Today,
                    EndLotSaleDate = DateTime.Today,
                    StartLotPrice = 10,
                    CurrentPrice = 14,                  
                    IsSold = false
                },
                 new Lot
                {
                    LotId = 2,
                    LotName = "WV",
                    LotImageUrl = "",
                    StarLotSaleDate = DateTime.Today,
                    EndLotSaleDate = DateTime.Today,
                    StartLotPrice = 20,
                    CurrentPrice = 27,              
                    IsSold = true
                },
                 new Lot
                {
                    LotId = 7,
                    LotName = "BMW",
                    LotImageUrl = "",
                    StarLotSaleDate = DateTime.Today,
                    EndLotSaleDate = DateTime.Today,
                    StartLotPrice = 50,
                    CurrentPrice = 54,                  
                    IsSold = false
                }
            };
        }
        [TestMethod]
        public void CRUDController_Get_All()
        {
            //Arrange          
            _moqDataBase.Setup(x => x.Lots.GetAll()).Returns(ListLot);            
            // Act
            var result = ((controller.Index() as ViewResult).Model) as IEnumerable<LotViewModel>;
            //Assert
            Assert.AreEqual(result.Count(), 3);
            Assert.AreEqual("Audi", result.ToList()[0].LotName);
            Assert.AreEqual("WV", result.ToList()[1].LotName);
            Assert.AreEqual("BMW", result.ToList()[2].LotName);
        }      
    }
}
