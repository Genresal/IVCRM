import { CardContent, Typography } from "@mui/material";
import { IOrder } from "../../models/IOrder";
import { StyledCard } from "../buildingBlocks/StyledComponents";

interface Props {
    order: IOrder
}

const OrderDetails: React.FC<Props> = ({ order }) => {

return (
    <StyledCard>
      <CardContent>
        <Typography variant="h5" component="div">
            Order status
        </Typography>
        <hr/>
        <Typography variant="body2">
            Id: {order.id}
        </Typography>
        <Typography variant="body2">
            Name: {order.name}
        </Typography>
        <Typography variant="body2">
            Order status: {order.orderStatus}
        </Typography>
        <Typography variant="body2">
            Order date: {order.orderDate}
        </Typography>
      </CardContent>
    </StyledCard>
);
}

export default OrderDetails;