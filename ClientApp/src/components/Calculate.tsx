import { Button, Input, InputOnChangeData, Label, Text } from "@fluentui/react-components";
import { useCallback, useMemo, useState } from "react";
import { Buffer } from 'buffer';
import { useStyles } from "../styles/styles";
import { Card, CardFooter, CardHeader, CardPreview } from "@fluentui/react-components/unstable";

export const Calculate: React.FunctionComponent = () => {
    const [environment, setEnvironment] = useState<string>("");
    const [apiKey, setApiKey] = useState<string>("");
    const [apiSecret, setApiSecret] = useState<string>("");
    const classes = useStyles();

    const updateEnvironment = useCallback((_ev, changeData: InputOnChangeData) => {
        setEnvironment(changeData.value ? changeData.value : "")
    }, [])

    const updateKey = useCallback((_ev, changeData: InputOnChangeData) => {
        setApiKey(changeData.value ? changeData.value : "")
    }, [])

    const updateSecret = useCallback((_ev, changeData: InputOnChangeData) => {
        setApiSecret(changeData.value ? changeData.value : "")
    }, [])

    const decoded: string = useMemo(() => {
        return environment && apiKey && apiSecret ? Buffer.from(`${apiKey}:${apiSecret}@${environment}`).toString('base64') : "";
    }, [environment, apiKey, apiSecret])

    const copyToClipboard = useCallback(() => {
        navigator.clipboard.writeText(decoded).then(() => {
            // TODO Add feedback
        }, (_err) => {
        });
    }, [decoded]);

    const prefix = <Text>https://</Text>
    const suffix = <Text>.simplicate.com</Text>
    const header = <Label size='large'>Calculate your API key</Label>

    return <>
        <Card className={classes.card} style={{ maxWidth: "500px" }}>
            <CardHeader header={header} />
            <CardPreview className={classes.cardDescripton}>
                <form>
                    <div className={classes.formField}>
                        <Label>Simplicate URL</Label>
                        <Input prefix="https://"
                            required
                            contentBefore={prefix}
                            contentAfter={suffix}
                            value={environment}
                            onChange={updateEnvironment}
                        />
                    </div>
                    <div className={classes.formField}>
                        <Label>Simplicate API Key</Label>
                        <Input required
                            value={apiKey}
                            onChange={updateKey} />
                    </div>
                    <div className={classes.formField}>
                        <Label>Simplicate API Secret</Label>
                        <Input required
                            value={apiSecret}
                            onChange={updateSecret} />
                    </div>
                    <div className={classes.formField}>
                        <Label>Simplicator API Key</Label>
                        <Input value={decoded}
                            disabled={true} />
                    </div>
                </form>
            </CardPreview>
            <CardFooter>
                <Button disabled={!decoded} onClick={copyToClipboard}>Copy to clipboard</Button>
            </CardFooter>
        </Card>

    </>
}