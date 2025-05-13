using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Dal.Respositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public PaymentRepository()
        {
            _context = new MiaDatabaseContext();
        }


        public async Task<List<Payment>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }


        public async Task<Payment> AddPayment(Payment model)
        {
            var newPayment = new Payment
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Mail = model.Mail,
                Date = model.Date,
                Amount = model.Amount,
                PhoneNumber = model.PhoneNumber,
                PaymentMode = model.PaymentMode,
                MailSent = model.MailSent,

            };

            _context.Payments.Add(newPayment);
            _context.SaveChanges();


            return newPayment;
        }

        public async Task<Payment> UpdatePayment(int IdPayment, Payment model)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var paymentToUpdate =  _context.Payments.FirstOrDefault(p => p.Id == IdPayment);

            if (paymentToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.FirstName != null) paymentToUpdate.FirstName = model.FirstName;
            if (model.LastName != null) paymentToUpdate.LastName = model.LastName;
            if (model.Mail != null) paymentToUpdate.Mail = model.Mail;
            if (model.PhoneNumber != null) paymentToUpdate.PhoneNumber = model.PhoneNumber;
            if (model.Date.HasValue) paymentToUpdate.Date = model.Date.Value;
            if (model.MailSent.HasValue) paymentToUpdate.MailSent = model.MailSent.Value;

            await _context.SaveChangesAsync();

            return paymentToUpdate;

        }


        public async Task<bool> DeletePayment(int IdPayment)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var paymentToDelete = await _context.Payments.FirstOrDefaultAsync(u => u.Id == IdPayment);

            if (paymentToDelete == null)
                return false; // ou throw une exception;


            _context.Payments.Remove(paymentToDelete);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
