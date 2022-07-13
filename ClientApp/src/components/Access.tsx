import { ActionButton, TextField } from "@fluentui/react";
import { useCallback, useMemo, useState } from "react";
import {Buffer} from 'buffer';

export const Access: React.FunctionComponent = () => {
    const [environment, setEnvironment] = useState<string>("");
    const [apiKey, seApiKey] = useState<string>("");
    const [apiSecret, setApiSecret] = useState<string>("");

    const updateEnvironment = useCallback((name: string | undefined) => {
        setEnvironment(name ? name : "")
    }, [])

    const updateKey = useCallback((name: string | undefined) => {
        seApiKey(name ? name : "")
    }, [])

    const updateSecret = useCallback((value: string | undefined) => {
        setApiSecret(value ? value : "")
    }, [])

    const decoded: string = useMemo(() => {
        return environment && apiKey && apiSecret ? Buffer.from(`${apiKey}:${apiSecret}@${environment}`).toString('base64') : "";
    }, [environment, apiKey, apiSecret])

    const copyToClipboard = useCallback(() => {
        navigator.clipboard.writeText(decoded).then(function () {
            console.log('Async: Copying to clipboard was successful!');
        }, function (err) {
            console.error('Async: Could not copy text: ', err);
        });
    }, [decoded]);

    return <>
        <div>
            <p>Calculate your API key</p>
            <form>
                <TextField label="Simplicate URL"
                    prefix="https://"
                    required
                    onChange={(_e, newValue) => updateEnvironment(newValue)}
                    value={environment}
                    suffix=".simplicate.com" />
                <TextField required
                    value={apiKey}
                    onChange={(_e, newValue) => updateKey(newValue)}
                    label="Simplicate API key" />
                <TextField required
                    value={apiSecret}
                    onChange={(_e, newValue) => updateSecret(newValue)}
                    label="Simplicate API secret" />
            </form>
            <br></br>
            <TextField value={decoded}
                onChange={(_e, newValue) => updateSecret(newValue)}
                label="Simplicator API Key"
                disabled={true}
                canRevealPassword />
            <ActionButton onClick={() => copyToClipboard()}>Copy to clipboard</ActionButton>
<br></br>
<br></br>
            <small>Calculation is browser-based. Your data is not stored anywhere.</small>
        </div>
    </>
}