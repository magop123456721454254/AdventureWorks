'use client';

import { ApolloProvider } from '@apollo/client';
import { client } from './functions/client';

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <ApolloProvider client={client}>
      {children}
    </ApolloProvider>
  );
}