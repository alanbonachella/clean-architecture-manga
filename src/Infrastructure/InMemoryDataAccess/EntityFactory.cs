namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;

    public sealed class EntityFactory : IUserFactory, ICustomerFactory, IAccountFactory
    {
        public IAccount NewAccount(CustomerId customerId) => new Account(customerId);

        public ICredit NewCredit(
            IAccount account,
            PositiveMoney amountToDeposit,
            DateTime transactionDate) => new Credit(account, amountToDeposit, transactionDate);

        public ICustomer NewCustomer(
            SSN ssn,
            Name name) => new Customer(ssn, name);

        public IDebit NewDebit(
            IAccount account,
            PositiveMoney amountToWithdraw,
            DateTime transactionDate) => new Debit(account, amountToWithdraw, transactionDate);

        public IUser NewUser(CustomerId customerId, ExternalUserId externalUserId) => new User(customerId, externalUserId);
    }
}
