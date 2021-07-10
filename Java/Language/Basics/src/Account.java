package banking;

//non-activatable type
public abstract class Account {

	long id;
	protected double balance;

	//pure method (must override)
	public abstract void deposit(double amount);

	public abstract void withdraw(double amount) throws InsufficientFundsException;

	public long getId() { return id; }

	public double getBalance() { return balance; }

	//non-overridable method
	public final void transfer(double amount, Account other) throws InsufficientFundsException {
		if(this == other)
			throw new IllegalTransferException();
		this.withdraw(amount);
		other.deposit(amount);
	}
}

