import React from "react"
import styles from "./PrimaryButton.module.css"
import ButtonProps from "../../types/buttonProps"
const PrimaryButton: React.FC<ButtonProps> = ({ text, onClick }) => {

    return (
        <button onClick={onClick} className={styles.primaryButton}>
            {text}
        </button>
    )

} 

export default PrimaryButton