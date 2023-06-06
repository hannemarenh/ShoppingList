"use client"
import { FunctionComponent, useState } from "react";
import Image from 'next/image'

type ListElementProps = {
    text: string
}

export const ListElement: FunctionComponent<ListElementProps> = ({ text }) => {
    const defaultTextStyle = "px-4"
    const doneTextStyle = defaultTextStyle + " " + "line-through";

    const [done, setDone] = useState(false);
    const [textStyle, setTextStyle] = useState(defaultTextStyle);

    const toggleDone = () => {
        setDone(!done);
        if (done === false) {
            setTextStyle(doneTextStyle);
        }
        else {
            setTextStyle(defaultTextStyle);
        }
    }

    return (
        <div onClick={toggleDone} className="flex m-4">
            <span>
                {done ?
                    <Image
                        src="/check.svg"
                        alt="check svg"
                        className="dark:invert"
                        width={24}
                        height={24}
                        rel="preload"
                    /> :
                    <Image
                        src="/shoppingCart.svg"
                        alt="Shopping cart"
                        className="dark:invert"
                        width={24}
                        height={24}
                        rel="preload"
                    />
                }
            </span>
            <p className={textStyle}> {text} </p>
        </div>
    )
}