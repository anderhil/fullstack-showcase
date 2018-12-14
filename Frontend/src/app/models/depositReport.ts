export class DepositReport {
  bankName: string;
  accountNumber: number;
  initialAmount: number;
  profitTax: number;
  interest: number;

  totalProfitBeforeTax: number;
  totalProfitAfterTax: number;
  totalProfitTax: number;
}
