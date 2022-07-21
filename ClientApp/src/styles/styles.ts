import { makeStyles } from "@fluentui/react-components";

export const useStyles = makeStyles({
    cardDescripton: {
        paddingLeft: "12px"
    },
    card: {
        marginBottom: "16px",
        maxWidth:"1000px"
    },
    formField: {
        maxWidth: "450px",
        display: "flex",
        flexDirection: "column",
        paddingBottom:"8px"
    },
    wrap: {
        whiteSpace: "pre-wrap"
    },
    form: {
        maxWidth:"450px"
    }
});