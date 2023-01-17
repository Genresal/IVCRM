import { IAddress } from "./IAddress";
import { IOrder } from "./IOrder";

export interface ICustomerDetails {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    dateOfBirth: Date;

    address: IAddress
    orders: IOrder[];
}