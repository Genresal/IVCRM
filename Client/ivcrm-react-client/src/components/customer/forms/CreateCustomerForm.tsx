import React, { useState } from "react";
import Button from "@mui/material/Button";
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import FormControl from '@mui/material/FormControl';
import { IChangeCustomer } from "../../../models/IChangeCustomer";

interface Props {
    createAction: (x: IChangeCustomer) => void
    handleClose: () => void
}

const CreateCustomerForm: React.FC<Props> = ({createAction, handleClose}) => {

    const [customer, setCustomer] = useState<IChangeCustomer>({id: 0, firstName: '', lastName: '', phoneNumber: ''})

    const handleSubmit = (e: React.MouseEvent<HTMLElement>) => {
        e.preventDefault()
    
        createAction(customer);
        setCustomer({id: 0, firstName: '', lastName: '', phoneNumber: ''});
        handleClose();
      }

      return (
        <FormControl>
            <Typography variant="h6" fontWeight={700}>Create new customer</Typography>

            <TextField 
                value={customer.firstName} 
                onChange={e => setCustomer({...customer, firstName: e.target.value})}  
                label="Fist Name" 
                variant="outlined" 
                margin="dense" 
                autoComplete='off'
                />
            <TextField 
                value={customer.lastName} 
                onChange={e => setCustomer({...customer, lastName: e.target.value})}
                label="Last Name" 
                variant="outlined" 
                margin="dense" 
                autoComplete='off'
                />
            <TextField 
                value={customer.phoneNumber} 
                onChange={e => setCustomer({...customer, phoneNumber: e.target.value})} 
                label="Phone Number" 
                variant="outlined" 
                margin="dense" 
                autoComplete='off'
                />

            <Button variant="contained" onClick={handleSubmit}>Save</Button>
        </FormControl>
      );
    }
    
    export default CreateCustomerForm;