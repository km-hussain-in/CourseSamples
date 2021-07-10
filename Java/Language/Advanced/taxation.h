#ifndef TAXATION_H
#define TAXATION_H

namespace Taxation
{
	class TaxPayer
	{
	public:
		TaxPayer(short);

		short Age() const;

		double IncomeTax(double) const;
	private:
		short age;
	};
}

#endif

