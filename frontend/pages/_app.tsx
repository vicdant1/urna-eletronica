import 'bootstrap/dist/css/bootstrap.min.css';
import '../styles/globals.css'
import 'jquery/dist/jquery.min.js'

import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import type { AppProps } from 'next/app'
import { useEffect } from 'react';

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
      <Component {...pageProps} />
    </>
  )
}

export default MyApp
