import { FaHome, FaDatabase, FaWpforms } from "react-icons/fa";
import 'bootstrap/dist/css/bootstrap.min.css';
import '../styles/globals.css'
import 'jquery/dist/jquery.min.js'

import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import type { AppProps } from 'next/app'
import { useEffect } from 'react';
import NavigateButton from '../components/NavigateButton/NavigateButton';

function MyApp({ Component, pageProps }: AppProps) 
{
  useEffect(() => {
    //@ts-ignore
    import("bootstrap/dist/js/bootstrap.bundle");
    //@ts-ignore
    window.$ = window.jQuery = require('jquery')
  }, []);

  return (
    <>
      <ToastContainer />
      <NavigateButton path='/' bgColor="#212529" bottomDistance="1rem"><FaHome/></NavigateButton>
      <NavigateButton path='/Cadastro' bgColor="#212529" bottomDistance="5rem"><FaWpforms/></NavigateButton>
      <NavigateButton path='/Dashboard' bgColor="#212529" bottomDistance="9rem"><FaDatabase/></NavigateButton>
      <Component {...pageProps} />
    </>
  )
}

export default MyApp
