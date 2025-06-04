import React, { useEffect, useState } from 'react';
import { NewFoodForm } from './NewFoodForm';
import {
  Button,
  Flex,
  SimpleGrid,
  Text,
  useDisclosure,
} from '@chakra-ui/react';
import { FoodItem } from './FoodItem';

export const FoodList = () => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const [listItems, setListItems] = useState([]);

  useEffect(() => {
    // TODO: Implement the HTTP request to set the listItems state defined above
    // TODO: This will be done by fetching all items from our backend based on requirements.
    const baseUrl = import.meta.env.VITE_API_BASE_URL;
    fetch(`${baseUrl}/api/food/all`)
    .then(result => result.json())
    .then(body => setListItems(body));
  }, []);

  return (
    <Flex direction={'column'} gap={5} w={'50%'} mx={'auto'}>
      <NewFoodForm isOpen={isOpen} onClose={onClose} />
      {sessionStorage.getItem('userGroup') === '1' && (
        <Button
          alignSelf={'center'}
          variant={'outline'}
          colorScheme="green"
          onClick={onOpen}
        >
        Create New Food
        </Button>)
      }
      

      <Text>
        You will need to implement code to display the food items here. Use the
        `FoodItem` component to display the individual items.  The "Create New Food" button above should
        be hidden unless you are an admin. Below are some example 'FoodItem' components
        that are acting as placeholders - please replace these with your own.
      </Text>
      <SimpleGrid columns={2} spacing={5}>
        { listItems.map(item => (
            <FoodItem key={item.foodId}
            foodId={item.foodId}
            name={item.name}
            description={item.description}
            listItems={listItems}
            setListItems={setListItems}
            />
          )
          )
        }
      </SimpleGrid>
    </Flex>
  );
};
