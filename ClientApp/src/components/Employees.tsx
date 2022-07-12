import { DetailsList, Spinner } from "@fluentui/react";
import { useEffect, useState } from "react";

const columns = [{ key: "name", name: "Name", fieldName: "name", minWidth: 200 }];

export const Employees: React.FunctionComponent = () => {
    const [employees, setEmployees] = useState(null);

    useEffect(() => {
        fetch("api/employees")
            .then(response => response.json())
            .then(data => setEmployees(data))
            .catch(error => console.log(error));
    }, []);

    return <>
        {employees ? <DetailsList items={employees} columns={columns} />
            : <Spinner />}
    </>
}