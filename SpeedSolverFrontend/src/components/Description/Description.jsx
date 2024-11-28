import styles from './Description.module.css'
import logo from '../../assets/logo.jpg'

const Description = () => {
    return (
        <div className={styles.description}>
            <div className={styles.leftsideText}>
                adsfadsafds
            </div>

            <div className={styles.rightImage}>
                <img src={logo} alt='asdads' className={styles.logo}></img>
            </div>
        </div>
    )
}

export default Description