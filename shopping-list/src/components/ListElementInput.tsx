"use client"
import { NextApiRequest } from "next";
import { FormEvent, FunctionComponent, useState } from "react";

export const ListElementInput: FunctionComponent = () => {
    const [newItem, setNewItem] = useState<string>("");

    const handleSubmit =  async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault(); // avoid page reload

        fetch("/api/listElement", {
            method: "POST",
            body: JSON.stringify({ newItem }),
            headers: {
                'Content-Type': 'application/json'
                }
        })
            .then(response => response.json())
            .then(data => console.log("Successfully posted: ",data))

        setNewItem("");
    }

    // TODO
    // clear textifeld on submit
    return (
        <form onSubmit={handleSubmit}>
            <label>
                {newItem}
                <input type="text" name="newItem" onChange={(e) => setNewItem(e.target.value)} />
            </label>
            <button type="submit">Submit</button>
        </form>
    )
}