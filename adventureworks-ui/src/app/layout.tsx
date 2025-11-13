'use client';

import { ApolloClient, InMemoryCache, gql, ApolloProvider, useQuery } from '@apollo/client';
export { ApolloClient, InMemoryCache, gql, ApolloProvider, useQuery };
import { client } from '../functions/client';

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <ApolloProvider client={client}>
      {children}
    </ApolloProvider>
  );
}