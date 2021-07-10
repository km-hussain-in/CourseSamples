class ObjectSerializationTest {

	public static void main(String[] args) throws Exception {
		var store = new tourism.SiteObjectStore();
		var site = store.fetch("CitiZoo");
		if(args.length > 0){
			String name = args[0].toLowerCase();
			var visitor = site.getVisitor(name);
			visitor.visit();
			System.out.printf("Welcome %s, your visit token is %d%n", name, visitor.getCurrentVisitToken());
			store.persist(site);
		}else{
			for(var v : site.getVisitors())
				System.out.printf("%s\t%d\t%s\t%d%n", v.getId(), v.getVisitCount(), v.getLastVisit(), v.getCurrentVisitToken());
		}
	}
}

