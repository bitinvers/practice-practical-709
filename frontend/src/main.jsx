import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'

import { ChakraProvider } from '@chakra-ui/react';
import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import { Root } from './pages/root/Root';
import { Home } from './pages/home/Home';
import { Login } from './pages/auth/Login';
import { FoodList } from './pages/itemlist/FoodList';


const router = createBrowserRouter([
  {
    element: <Root />,
    path: '',
    children: [
      {
        element: <Home />,
        path: '',
      },
      {
        element: <Login />,
        path: 'login',
      },
      {
        element: <FoodList />,
        path: 'item-list',
      },
    ],
  },
]);

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <ChakraProvider>
      <RouterProvider router={router} />
    </ChakraProvider>
  </StrictMode>,
)
