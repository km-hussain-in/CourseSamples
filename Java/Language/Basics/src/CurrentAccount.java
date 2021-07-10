package banking;

//non-extendible class
final class CurrentAccount extends Account {

	public void deposit(double amount) {
		if(balance < 0)
			amount *= 0.9;
		balance += amount;
	}
	
	public void withdraw(double amount) throws InsufficientFundsException {
		balance -= amount;
	}
}

