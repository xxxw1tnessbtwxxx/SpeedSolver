import { Divider } from 'antd';
import styles from './InfoCard.module.css'

export default function InfoCard(props) {
    return (
        <div className={styles.card}>
            <span>Image here</span>
            <Divider/>
            <div className="text-section">
                <h3 className={styles.title}>{props.title}</h3>
                <span>{props.description}</span>
            </div>
        </div>    
    );
}