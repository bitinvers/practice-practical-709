import {
  Button,
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalCloseButton,
  ModalBody,
  ModalFooter,
  Input,
} from '@chakra-ui/react';
import React, { useRef } from 'react';
import { useNavigate } from 'react-router-dom';

export const NewFoodForm = ({ isOpen, onClose }) => {

  const navigate = useNavigate()

  const SubmitFormHandler = () => {

    const name = foodName.current.value;
    const description = foodDescription.current.value; 

    const newFormRequest = {
      "name": name,
      "description": description,
      "restaurantId": 1
    }

    const baseUrl = import.meta.env.VITE_API_BASE_URL;
    fetch(`${baseUrl}/api/food/create`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${sessionStorage.getItem('token')}`
      },
      body: JSON.stringify(newFormRequest)
    })
    .then(res => res.json()
    .then(success => {
      if(success) navigate(0)
    }))


    // TODO: Implement the logic to make an HTTP request to create a new item in the backend.
    // TODO: The data will need to be sent from the form that is created below.
    // TODO: You can use either useState or useRef hooks to get the data from the form into the request.
  };

  const foodName = useRef('')
  const foodDescription = useRef('')

  return (
    <Modal isOpen={isOpen} onClose={onClose}>
      <ModalOverlay />
      <ModalContent>
        <ModalHeader>Create New Food</ModalHeader>
        <ModalCloseButton />
        <ModalBody>
          Add the form elements here that you will use to send the request to
          the backend that allows you to create a new food item. Here is a
          placeholder input element to get you started :)
          <Input ref={foodName} placeholder="Name" />
          <Input ref={foodDescription} placeholder="Description" />
        </ModalBody>

        <ModalFooter>
          <Button
            colorScheme="gray"
            variant={'outline'}
            mr={3}
            onClick={onClose}
          >
            Close
          </Button>
          <Button onClick={SubmitFormHandler} variant="outline" colorScheme="green">
            Create
          </Button>
        </ModalFooter>
      </ModalContent>
    </Modal>
  );
};
