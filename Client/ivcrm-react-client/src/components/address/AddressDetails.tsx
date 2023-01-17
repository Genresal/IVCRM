import { CardContent, Typography } from "@mui/material";
import { IAddress } from "../../models/IAddress";
import { StyledCard } from "../buildingBlocks/StyledComponents";

interface Props {
    address: IAddress
}

const AddressDetails: React.FC<Props> = ({ address }) => {

return (
<StyledCard>
    <CardContent>
    <Typography variant="h5" component="div">
        Address
    </Typography>
    <hr/>
    {address ?
        <>
    <Typography variant="body2">
        Id: {address.id}
    </Typography>
    <Typography variant="body2">
        Street: {address.street}
    </Typography>
    <Typography variant="body2">
        City: {address.city}
    </Typography>
    <Typography variant="body2">
        State: {address.state}
    </Typography>
    <Typography variant="body2">
        Zip code: {address.zipCode}
    </Typography>
        </>
      : 
      <Typography variant="body2">
      No address provided.
  </Typography>}

    </CardContent>
</StyledCard>
);
}

export default AddressDetails;