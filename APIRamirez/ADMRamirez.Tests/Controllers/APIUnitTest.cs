using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APIRamirez.Controllers;
using APIRamirez.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADMRamirez.Tests.Controllers
{
    [TestClass]
    public class APIUnitTest
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            APIramirezsController aPIramirezsController = new APIramirezsController();

            //Act
            var ListaReg = aPIramirezsController.GetAPIramirezs();

            //Assert
            Assert.IsNotNull(ListaReg);
        }

        [TestMethod]
        public void TestPost()
        {
            //Arrange
            APIramirezsController aPIramirezsController = new APIramirezsController();
            APIramirez aP = new APIramirez()
            {
                FriendofRamirez="Francisco Zenteno",
                RamirezID=217896,
                Place=Place.LPZ,
                Email="zenteno@gmail.com",
                Birthdate=DateTime.Today
            };

            //Act
            IHttpActionResult actionResult = aPIramirezsController.PostAPIramirez(aP);
            var reg_act = actionResult as CreatedAtRouteNegotiatedContentResult<APIramirez>;

            //Assert
            Assert.IsNotNull(reg_act);
            Assert.AreEqual("DefaultApi", reg_act.RouteName);
            Assert.AreEqual(aP.FriendofRamirez, reg_act.Content.FriendofRamirez);
            Assert.AreEqual(aP.Email, reg_act.Content.Email);
            Assert.AreEqual(aP.Birthdate, reg_act.Content.Birthdate);
            Assert.AreEqual(aP.Place, reg_act.Content.Place);
        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            APIramirezsController aPIramirezsController = new APIramirezsController();
            APIramirez aP = new APIramirez()
            {
                FriendofRamirez = "Francisco Zenteno",
                RamirezID = 217896,
                Place = Place.LPZ,
                Email = "zenteno@gmail.com",
                Birthdate = DateTime.Today
            };

            //Act
            IHttpActionResult actionResult = aPIramirezsController.DeleteAPIramirez(aP.RamirezID);

            //Assert
            Assert.IsNotInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void TestPut()
        {
            //Arrange
            APIramirezsController aPIramirezsController = new APIramirezsController();
            APIramirez aP = new APIramirez()
            {
                FriendofRamirez = "Francisco Zenteno",
                RamirezID = 217896,
                Place = Place.LPZ,
                Email = "zenteno@gmail.com",
                Birthdate = DateTime.Today
            };
            string newFriendofRamirez = "Galia";

            //Act
            var actionResult = aPIramirezsController.PostAPIramirez(aP);
            aP.FriendofRamirez = newFriendofRamirez;
            var actionResultPut = aPIramirezsController.PutAPIramirez(aP.RamirezID, aP) as StatusCodeResult;

            //Assert
            Assert.IsNotNull(actionResultPut);
            Assert.AreEqual(HttpStatusCode.NoContent, actionResultPut.StatusCode);
            Assert.IsInstanceOfType(actionResultPut, typeof(StatusCodeResult));
        }
    }
}
