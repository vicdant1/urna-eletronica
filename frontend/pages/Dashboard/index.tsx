import axios from "axios";
import { NextPage } from "next";
import { useEffect, useState } from "react";
import style from './dashboard.module.css'

import { buildStyles, CircularProgressbar } from 'react-circular-progressbar';
import 'react-circular-progressbar/dist/styles.css';
import Link from "next/link";

const Dashboard: NextPage = () => {
  
  const [candidatos, setCandidatos] = useState<any[]>([]);
  const [nullVotesAmount, setNullVotesAmount] = useState<number>(0);

  const fetchData = async () => {
    await axios.get('http://localhost:5222/votes')
      .then(res => setCandidatos(res.data))
      .catch(err => console.log(err));

    await axios.get('http://localhost:5222/getNullVotesAmount')
      .then(res => setNullVotesAmount(res.data.nullVotesAmount))
  }

  const calcProgressVal = (candidato) => {
    let totalVotes = 0;
    candidatos.forEach(candidato => {
      totalVotes += candidato.votoAmount;
    });
    if(totalVotes == 0 && nullVotesAmount == 0) totalVotes++;

    
    if(candidato != null)
      return Math.floor((candidato.votoAmount / (nullVotesAmount + totalVotes)) * 100);
    else
      return Math.floor((nullVotesAmount / (nullVotesAmount + totalVotes)) * 100);
  }

  useEffect(() => {
    fetchData();
  }, []);
  return (
    <div className="container">
      <h2 className="text-center mt-4">Dashboard</h2>
      {candidatos.length > 0 ? (
        <table className="table table-striped mt-4">
          <thead>
            <tr>
              <th scope="col">Número</th>
              <th scope="col">Nome</th>
              <th scope="col">Vice</th>
              <th scope="col" className="text-center">Qtd. Votos</th>
              <th scope="col" className="text-center">Legenda</th>
            </tr>
          </thead>
          <tbody>
            {candidatos.map((candidato, index) => (
              <tr key={index}>
                <th scope="row">{candidato.id}</th>
                <td>{candidato.nomeCompleto}</td>
                <td>{candidato.nomeVice}</td>
                <td className="text-center">{candidato.votoAmount}</td>
                <td className="text-center d-flex align-items-center justify-content-center">
                  <div className={style.circularProgress}>
                    <CircularProgressbar value={calcProgressVal(candidato)} maxValue={100} text={`${calcProgressVal(candidato)}%`}/>  
                  </div>
                </td>
              </tr>
            ))}
            {nullVotesAmount > 0 && (
              <tr>
                <th scope="row">Brancos e Nulos</th>
                <td>-</td>
                <td>-</td>
                <td className="text-center">{nullVotesAmount}</td>
                <td className="text-center d-flex align-items-center justify-content-center">
                  <div className={style.circularProgress}>
                    <CircularProgressbar value={calcProgressVal(null)} maxValue={100} text={`${calcProgressVal(null)}%`}/>  
                  </div>
                </td>
              </tr>
            )}
          </tbody>
        </table>
      ) : (
        <div className={`${style.emptyPage}`}>
          <h5 className="text-center text-muted">Não há candidatos cadastrados na eleição. <hr />
            <Link href='/'>Voltar</Link>
          </h5>
        </div>
      )}
    </div>
  );
}

export default Dashboard;