import Link from "next/link";
import style from './navigateButton.module.css';

interface Props {
  path: string;
  children: any;
  bgColor: string;
  bottomDistance: string;
}

const NavigateButton = ({path, children, bgColor, bottomDistance}:Props) => {
  return (
    <div>
      <Link href={path}>
        <div className={style.buttonContainer} style={{backgroundColor: bgColor, bottom: bottomDistance}}>
          {children}
        </div>
      </Link>
    </div>
  );
}

export default NavigateButton;