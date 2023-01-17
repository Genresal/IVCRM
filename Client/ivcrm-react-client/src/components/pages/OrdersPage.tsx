import { CircularProgress, Divider, Grid } from '@mui/material';
import ModalWrapper from '../buildingBlocks/ModalWrapper';
import { Add } from '@mui/icons-material';
import CreateOrderForm from '../orders/forms/CreateOrderForm';
import OrderTable from '../orders/OrderTable';
import { useAppDispatch, useAppSelector } from '../../hooks/redux';
import { fetchOrders } from '../../store/reducers/orders/ActionCreators';
import { useEffect } from 'react';

function OrdersPage() {
  const {orders, isLoading, error} = useAppSelector(state => state.orderReducer);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchOrders())
  }, [])

  return (
    <Grid direction='row' container spacing={1}>
    <Grid container item sm={3}>
        filters...
    </Grid>
    <Divider orientation="vertical" flexItem/>
    <Grid container item sm={9}>
        <ModalWrapper icon={<Add />}>
            <CreateOrderForm/>
        </ModalWrapper>
        {isLoading && <CircularProgress />}
            {error && <h1>{error}</h1>}
      <OrderTable orders={orders}/>
    </Grid>
  </Grid>
  );
}

export default OrdersPage;