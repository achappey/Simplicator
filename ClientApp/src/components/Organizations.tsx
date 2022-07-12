import { DetailsList, Spinner } from "@fluentui/react";
import { useEffect, useState } from "react";

const columns = [{ key: "name", name: "Name", fieldName: "name", minWidth: 200 }];

export const Organizations: React.FunctionComponent = () => {
    const [organizations, setOrganizations] = useState(null);

    useEffect(() => {
        fetch("api/organizations")
            .then(response => response.json())
            .then(data => setOrganizations(data))
            .catch(error => console.log(error));
    }, []);

    return <>{organizations ? <DetailsList items={organizations} columns={columns} /> : <Spinner />}</>
}