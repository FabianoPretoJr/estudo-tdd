using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            
            command.FirstName = "João";
            command.LastName = "Oliveira";
            command.Document = "99999999999";
            command.Email = "fabiano@gft.com";

            command.BarCode = "123456789";
            command.BoletoNumber = "1234654987";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;  
            command.Payer = "João Oliveira";
            command.PayerDocument = "12345678910";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "joao@gft.com";

            command.Street = "Rua Josefina";
            command.AddressNumber = "254";
            command.Neighborhood = "Jardim das Flores";
            command.City = "São Paulo";
            command.Country = "SP";
            command.ZipCode = "12345-678";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}