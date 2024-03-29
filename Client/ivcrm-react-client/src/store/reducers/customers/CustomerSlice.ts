import { ICustomer } from "../../../models/ICustomer";
import { IPagedList } from "../../../models/IPagedList";
import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { createCustomer, deleteCustomer, getCustomerById, fetchCustomers, updateCustomer } from "./ActionCreators";
import { IPaginationData } from "../../../models/IPaginationData";
import { ICustomerDetails } from "../../../models/ICustomerDetails";
import { IAddress } from "../../../models/IAddress";
import { IOrder } from "../../../models/IOrder";

interface ICustomerState {
    paginationData: IPaginationData;
    customers: ICustomer[];
    customer: ICustomerDetails;
    isLoading: boolean;
    error: string;
}

const initialState: ICustomerState = {
    paginationData: {pageSize: 10, currentPage: 0, totalCount: 0, totalPages: 0} as IPaginationData,
    customers: [],
    customer: {address: {} as IAddress, orders: new Array<IOrder>} as ICustomerDetails,
    isLoading: false,
    error: '',
}

export const customerSlice = createSlice({
    name: 'customer',
    initialState,
    reducers: {},
    extraReducers: {
        [fetchCustomers.fulfilled.type]: (state, action: PayloadAction<IPagedList<ICustomer>>) => {
            state.isLoading = false;
            state.error = '';
            state.customers = action.payload.data;
            state.paginationData = {
                pageSize: action.payload.pageSize,
                totalPages: action.payload.totalPages,
                currentPage: action.payload.currentPage,
                totalCount: action.payload.totalCount,
            };
        },
        [fetchCustomers.pending.type]: (state) => {
            state.isLoading = true;
        },
        [fetchCustomers.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [getCustomerById.fulfilled.type]: (state, action: PayloadAction<ICustomerDetails>) => {
            state.isLoading = false;
            state.error = '';
            state.customer = action.payload;
        },
        [getCustomerById.pending.type]: (state) => {
            state.isLoading = true;
        },
        [getCustomerById.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [createCustomer.fulfilled.type]: (state, action: PayloadAction<ICustomer>) => {
            state.isLoading = false;
            state.error = '';
            state.customers = [...state.customers,  action.payload];
        },
        [createCustomer.pending.type]: (state) => {
            state.isLoading = true;
        },
        [createCustomer.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [updateCustomer.fulfilled.type]: (state, action: PayloadAction<ICustomer>) => {
            state.isLoading = false;
            state.error = '';
            state.customers = state.customers.map((item) => item.id === action.payload.id ? action.payload : item);
        },
        [updateCustomer.pending.type]: (state) => {
            state.isLoading = true;
        },
        [updateCustomer.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
        [deleteCustomer.fulfilled.type]: (state, action: any) => {
            state.isLoading = false;
            state.error = '';
            state.customers = state.customers.filter(x => x.id !== action.meta.arg);
        },
        [deleteCustomer.pending.type]: (state) => {
            state.isLoading = true;
        },
        [deleteCustomer.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },
    }
})

export default customerSlice.reducer;
