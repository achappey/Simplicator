import React from 'react';
import { Link } from '@fluentui/react';

export const Home: React.FunctionComponent = () => {
  return (
    <div>
      <h2>Power Platform connector for <Link href="https://www.simplicate.com" target={"_blank"}>Simplicate</Link></h2>

      <h4>Authentication</h4>
      <p>Add as query string or in the request header:</p>
      <code>x-api-key: base64Encode([SimplicateApiKey]:[SimplicateApiSecret]@[SimplicateEnvironment])</code>
      <p>
      Calculate your API Key <Link href={"/access"}>here</Link>.
      </p>
      <h4>Documentation</h4>
      <ul>
        <li>Swagger: <Link href={"/swagger/index.html"} target={"_blank"}>HTML</Link> | <Link href={"/swagger/v2/swagger.json"} target={"_blank"}>JSON</Link> | <Link href={"/swagger/v2/swagger.yaml"} target={"_blank"}>YAML</Link></li>
        <li>OData: <Link href={"/odata"} target={"_blank"}>https://simplicator.net/odata</Link> | <Link href={"/odata$metadata"} target={"_blank"}>Metadata</Link></li>
        <li>Source: <Link href={"https://github.com/achappey/Simplicator"} target={"_blank"}>GitHub</Link></li>
      </ul>
    </div>
  );
}
