import { DetailsList, Spinner } from "@fluentui/react";
import { useEffect, useState } from "react";

const columns = [{ key: "name", name: "Name", fieldName: "name", minWidth: 200 }];

export const Projects: React.FunctionComponent = () => {
    const [projects, setProjects] = useState(null);

    useEffect(() => {
        fetch("api/projects")
            .then(response => response.json())
            .then(data => setProjects(data))
            .catch(error => console.log(error));
    }, []);

    return <>
        {projects ? <DetailsList items={projects} columns={columns} />
            : <Spinner />}
    </>
}