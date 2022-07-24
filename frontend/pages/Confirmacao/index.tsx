import { NextPage } from "next";
import Link from "next/link";
import style from './confirmacao.module.css';

const Confirmacao: NextPage = () => {
  return (
    <div className={style.mainPage}>
      <div className={`${style.boxHolder}`}>
        <h3>Confirmação realizada</h3>
        <hr />
        <p><Link href='/'><a className={style.backLink}>Voltar à tela de votação.</a></Link></p>
      </div>
    </div>
  );
}

export default Confirmacao;