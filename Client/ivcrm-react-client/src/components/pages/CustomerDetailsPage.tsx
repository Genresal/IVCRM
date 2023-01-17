import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { useParams } from 'react-router-dom';
import { useEffect } from 'react';
import { getCustomerById } from '../../store/reducers/customers/ActionCreators';
import CustomerDetails from '../customer/CustomerDetails';
import { Grid } from '@mui/material';
import OrderTable from '../orders/OrderTable';
import { ICustomer } from '../../models/ICustomer';
import AddressDetails from '../address/AddressDetails';

const CustomerDetailsPage = () => {

  const {customer} = useAppSelector(state => state.customerReducer)
  const params = useParams();
  const dispatch = useAppDispatch()
  
  var customerId = 0;
if (typeof(params.customerId) !== 'undefined' && params.customerId != null) {
  customerId = parseInt(params.customerId, 10);
}

console.log(customer);

useEffect(() => {
  dispatch(getCustomerById(customerId))
}, [])

  return (
    <Grid container spacing={2} alignItems="stretch">
      <Grid item style={{display: "flex"}} xs={12} sm={12} md={6} lg={6} xl={6}>
        <CustomerDetails customer={customer as ICustomer}/>
      </Grid>
      <Grid item style={{display: "flex"}} xs={12} sm={12} md={6} lg={6} xl={6}>
        <AddressDetails address={customer.address}/>
      </Grid>
      <Grid item style={{display: "flex"}} xs={12}>
        <OrderTable orders={customer.orders}/>
      </Grid>
    </Grid>
  );
}

export default CustomerDetailsPage;
