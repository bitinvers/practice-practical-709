import {
  Card,
  CardHeader,
  CardBody,
  Heading,
  CardFooter,
  Button,
} from '@chakra-ui/react';
import React from 'react';

export const FoodItem = ({foodId, name, description, listItems, setListItems}) => {

  const handleDelete = () => {
    const baseUrl = import.meta.env.VITE_API_BASE_URL;
    fetch(`${baseUrl}/api/food/delete/${foodId}`, {
      method: 'DELETE',
      headers: {
        Authorization: `Bearer ${sessionStorage.getItem('token')}`
      }
    })
    .then(res => res.json())
    .then(success => {
      console.log(success);
      if(success){
        const newItems = listItems.filter(item => item.foodId !== foodId);
        setListItems([... newItems])
      }
    })
  }




  return (
    <Card>
      <CardHeader>
        <Heading size="md">
          {name}
        </Heading>
      </CardHeader>

      <CardBody>
        {description === null ? 'No Description' : description}
      </CardBody>
      <CardFooter>
        {sessionStorage.getItem('userGroup') === '1' && (
        <Button onClick={handleDelete} variant={'outline'} colorScheme="red">
          Delete
        </Button> )}
      </CardFooter>
    </Card>
  );
};
