import { ItemList } from '../components/ItemList';
import { ListElement } from '../components/ListElement'
import { ListElementInput } from '../components/ListElementInput';

export default function Home() {
    return (
        <main className="">
            <ListElementInput />

            <div>
                My new list:
                <div>
                    <ItemList />
                </div>
            </div>
        </main>
    )
}
