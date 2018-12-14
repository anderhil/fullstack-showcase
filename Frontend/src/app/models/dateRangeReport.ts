import {DepositReport} from './depositReport';

export class DateRangeReport {
  userName: string;
  fullName: number;
  email: number;

  depositReports: DepositReport[];

  depositsProfitBeforeTax: number;
  depositsProfitAfterTax: number;
  depositsProfitTax: number;

  startDate: Date;
  endDate: Date;
  periodInDays: number;
}





