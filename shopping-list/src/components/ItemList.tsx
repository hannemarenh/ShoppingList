"use client"
import { FunctionComponent, useEffect, useState } from "react";
import { ListElement } from "./ListElement";

type Item = {
    id: string;
    item: string;
}

export const ItemList: FunctionComponent = () => {
    const [items, setItems] = useState<Array<Item>>([])

    useEffect(() => {
        fetch("/api/listElement", {
            method: "GET",
        })
            .then((response) => { return response.json() })
            .then((data) => { setItems(data.collection) })



    }, [])


    return (<>
        {
            items.map((current: Item) => { return (<ListElement key={current.id} text={current.item} />) })
        }
    </>)
}