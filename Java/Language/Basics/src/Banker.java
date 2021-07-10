package banking;

//factory class
public class Banker {

	private static long nid = 1;

	public static Account openCurrentAccount() {
		var acc = new CurrentAccount();
		acc.id = 1000000 + nid++;
		return acc;
	}

	public static Account openSavingsAccount() {
		var acc = new SavingsAccount();
		acc.id = 2000000 + nid++;
		return acc;
	}

	//all members of this class are static so there's no reason to create its instances
	private Banker() {}
}

